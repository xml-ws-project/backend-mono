using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Models.ApplicationUsers;
using MonoLibrary.Core.Models.Enums;
using MonoLibrary.Core.Repository;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service;
using MonoLibrary.Core.Service.Core;
using MonoLibrary.Core.Services.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Services
{
    public class TicketService: BaseService<Ticket>, ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly UserManager<User> _userManager;

        public TicketService(ITicketRepository ticketRepository,IFlightRepository flightRepository, UserManager<User> userManager) : base(ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _flightRepository = flightRepository;
            _userManager = userManager;
        }

        public bool Create(CreateTicketDTO dto)
        {
            Flight flight = _flightRepository.Get(dto.FlightId.ToString());
           
            
            if (!CanCreateTickets(flight,dto)) 
            { 
                return false; 
            }

            double price = CalculatePrice(flight, dto);
            int[] seatNumbers = GenerateSeats(flight, dto);

            for (int i = 0; i <dto.NumberOfTickets; i++) {

                Ticket ticket = new Ticket(seatNumbers[i], dto.UserId, dto.FlightId, price, dto.AdditionalLuggage, dto.PassengerClass);
                _ticketRepository.Add(ticket);
            }
            
            _ticketRepository.Commit();

            return true;
        }

        private bool CanCreateTickets(Flight flight, CreateTicketDTO dto)
        {
            bool areEnoughSetsLeft = CheckIfThereAreSufficientNumberOfSeatsLeft(flight, dto.NumberOfTickets, dto.PassengerClass);
            bool areSeatsSelectedCorrectly = CheckIfSeatsSelectedCorrectly(flight, dto);
            bool isNumberOfSelectedSeatsCorrect = CheckIfNumberOfSelectedSeatsIsCorrect(dto.SeatNumbers.Length, dto.NumberOfTickets);
            if (!areEnoughSetsLeft || !areSeatsSelectedCorrectly || !isNumberOfSelectedSeatsCorrect)
            {
                return false;
            }
            return true;
        }

        private bool CheckIfThereAreSufficientNumberOfSeatsLeft(Flight flight, int numberOfTickets, PassengerClass passengerClass)
        {
            if (passengerClass == PassengerClass.ECONOMY)
            {
                if (numberOfTickets > flight.GetRemainingSeats(true))
                {
                    return false;
                }
            }
            else
            {
                if (numberOfTickets > flight.GetRemainingSeats(false))
                {
                    return false;
                }
            }
            return true;
        }

        private double CalculatePrice(Flight flight, CreateTicketDTO dto)
        {
            double price = CalculatePriceForPassengerClass(flight,dto.PassengerClass);
            price += CalculateAdditionalCosts(dto.AdditionalLuggage,dto.SeatNumbers);
            return price;
        }

        private double CalculatePriceForPassengerClass(Flight flight, PassengerClass passengerClass)
        {
            double price = 0;
            if (passengerClass == PassengerClass.ECONOMY)
            {
                price += flight.Pricelist[PassengerClass.ECONOMY];
            }
            else
            {
                price += flight.Pricelist[PassengerClass.BUSINESS];
            }
            return price;
        }
        private  double CalculateAdditionalCosts(bool additionalLuggage, int[] seatNumber)
        {
            double price = 0;
            if (additionalLuggage)
            {
                price += 50;
            }
            if(seatNumber != null)
            {
                price += 10;
            }
            return price;
        }

        private int[] GenerateSeats(Flight flight,CreateTicketDTO dto)
        {
            if (dto.SeatNumbers.Length == 0)
            {
                dto.SeatNumbers = new int[dto.NumberOfTickets];
                for (int i = 0; i < dto.NumberOfTickets; i++)
                {
                    dto.SeatNumbers[i] = flight.TakeFirstFreeSeat(dto.PassengerClass);
                }
            }
            else
            {
                for (int i = 0; i < dto.SeatNumbers.Length; i++)
                {
                    flight.UpdateRemainingSeats(dto.PassengerClass, dto.SeatNumbers[i]);
                }
            }
            _flightRepository.Update(flight);
            _flightRepository.Commit();
            return dto.SeatNumbers;
        }
        private bool CheckIfSeatsSelectedCorrectly(Flight flight, CreateTicketDTO dto)
        {
            if (dto.SeatNumbers.Length != 0 && (dto.NumberOfTickets != dto.SeatNumbers.Length))
            {
                return false;
            }
            if (dto.PassengerClass == PassengerClass.ECONOMY)
            {
                return CheckIfSeatNumbersAreCorrect(flight.EconomySeats, dto.SeatNumbers);
            }
            else
            {
                return CheckIfSeatNumbersAreCorrect(flight.BusinessSeats, dto.SeatNumbers);
            }
        }

        private bool CheckIfNumberOfSelectedSeatsIsCorrect(int selectedSeats, int numberOfticfkets)
        {
            
            if (selectedSeats == numberOfticfkets || selectedSeats == 0)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfSeatNumbersAreCorrect(int[] flightSeats, int[] selectedSeats)
        {
            for (int i = 0; i < selectedSeats.Length; i++)
            {
                int seatNumber = selectedSeats[i];
                if (flightSeats[seatNumber] == -1)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<Ticket> GetActiveTicketsForUser(string id)
        {
            List<Ticket> tickets = (List<Ticket>)_ticketRepository.GetAllTicketsForUser(id);
            List<Ticket> activeTickets = new List<Ticket>();
         
            
            foreach(Ticket ticket in tickets)
            {
                Flight flight = _flightRepository.Get(ticket.FlightId);
                if (flight.LandingDateTime < DateTime.Now) 
                {
                    activeTickets.Add(ticket);
                }

            }
            return activeTickets;
        
        }
        
        

       

    }
}
