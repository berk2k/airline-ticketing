using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using se4458_midterm.Models;
using se4458_midterm.Models.Dto;
using se4458_midterm.Source.Svc;
using System.Net;

namespace se4458_midterm.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    public class BuyTicketController : ControllerBase
    {
        private IFlightService _flightService;
        private IMapper _mapper;
        
        protected BuyTicketResponse _buyTicketResponse;

        public BuyTicketController(IFlightService flightService,IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
            
            _buyTicketResponse = new();
        }

        [HttpPost("Buy Ticket")]
        [Authorize]
        public ActionResult<BuyTicketResponse> BuyTicket([FromBody] BuyTicketDTO buyTicketDTO)
        {
            try
            {
                Flight flight = _flightService.GetFlightByNumber(buyTicketDTO.FlightNumber);

                if (flight == null)
                {
                    _buyTicketResponse.Status = "FAIL TO BUY";
                    _buyTicketResponse.StatusCode = HttpStatusCode.NotFound;
                    _buyTicketResponse.IsSuccess = false;
                    _buyTicketResponse.ErrorMessage = "There is no flight with given parameters";

                    return NotFound(_buyTicketResponse);
                }

                if(flight.DepartureDate.Date != buyTicketDTO.Date.Date)
                {
                    _buyTicketResponse.Status = "FAIL TO BUY";
                    _buyTicketResponse.StatusCode = HttpStatusCode.NotFound;
                    _buyTicketResponse.IsSuccess = false;
                    _buyTicketResponse.ErrorMessage = "There is no flight with given date";

                    return NotFound(_buyTicketResponse);
                }
                if (flight.Departure.ToLower() != buyTicketDTO.From.ToLower() && flight.Destination.ToLower() != buyTicketDTO.To.ToLower())
                {
                    _buyTicketResponse.Status = "FAIL TO BUY";
                    _buyTicketResponse.StatusCode = HttpStatusCode.NotFound;
                    _buyTicketResponse.IsSuccess = false;
                    _buyTicketResponse.ErrorMessage = "There is no flight with Destination";

                    return NotFound(_buyTicketResponse);
                }

                if (flight.AvailableSeats == 0)
                {
                    _buyTicketResponse.Status = "FAIL TO BUY";
                    _buyTicketResponse.StatusCode = HttpStatusCode.NotFound;
                    _buyTicketResponse.IsSuccess = false;
                    _buyTicketResponse.ErrorMessage = "There are no available seats in the flight";

                    return BadRequest(_buyTicketResponse);
                }


                _buyTicketResponse.AvailableSeatsBeforeBuyTransaction = flight.AvailableSeats;

                Flight bookedFlight = _flightService.BookFlight(flight);

                _buyTicketResponse.Status = "SUCCESS";
                _buyTicketResponse.StatusCode = HttpStatusCode.OK;
                _buyTicketResponse.IsSuccess = true;
                
                _buyTicketResponse.AvailableSeatsAfterBuyTransaction = bookedFlight.AvailableSeats;
                _buyTicketResponse.Result = _mapper.Map<BuyTicketDTO>(buyTicketDTO);
                
                return Ok(_buyTicketResponse);

            }
            catch (Exception ex)
            {

                _buyTicketResponse.Status = "FAIL";
                _buyTicketResponse.IsSuccess = false;
                _buyTicketResponse.ErrorMessage = ex.ToString();


            }
            return _buyTicketResponse;
        }

    }
}
