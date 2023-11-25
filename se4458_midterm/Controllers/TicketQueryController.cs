using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
    public class TicketQueryController : ControllerBase
    {
        private IFlightService _flightService;
        
        protected APIResponse _response;

        public TicketQueryController(IFlightService flightService)
        {
            _flightService = flightService;
            
            _response = new();
        }

        [HttpGet("QueryTickets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> QueryTickets([FromQuery] TicketQueryDTO ticketQueryDTO)
        {
            try
            {

                List<Flight> queryList = _flightService.QueryFlight(ticketQueryDTO.Date, ticketQueryDTO.From, ticketQueryDTO.To, ticketQueryDTO.NumberOfPeople);

                


                if (queryList.IsNullOrEmpty())
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.Status = "Fail";
                    _response.ErrorMessage = "There is no flight with given parameters";

                    return NotFound(_response);
                }

                

                List<TicketQueryResultDTO> outputList = queryList.Select(f => new TicketQueryResultDTO
                {
                    FlightNumber = f.FlightNumber,
                    Price = f.Price,
                    Date = f.DepartureDate.Date,
                }).ToList();

                return Ok(outputList);
            }
            catch (Exception ex)
            {

                _response.Status = "Fail";
                _response.IsSuccess = false;
                _response.ErrorMessage = ex.ToString();
                
            }
            return _response;
            
        }

        [HttpPost("GetQueryWithPaging")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> QueryTicketsWithPaging([FromBody] TicketQueryWithPagingDTO ticketQueryDTO)
        {
            try
            {
                
                List<Flight> queryList = _flightService.QueryFlight(ticketQueryDTO.Date, ticketQueryDTO.From, ticketQueryDTO.To, ticketQueryDTO.NumberOfPeople);




                if (queryList.IsNullOrEmpty())
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.Status = "Fail";
                    _response.ErrorMessage = "There is no flight with given parameters";

                    return NotFound(_response);
                }

                if (ticketQueryDTO.PageSize > 10)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.Status = "Fail";
                    _response.ErrorMessage = "Max page size is 10";

                    return BadRequest(_response);
                }

                List<TicketQueryResultDTO> outputList = queryList
                    .Skip((ticketQueryDTO.PageNumber - 1) * ticketQueryDTO.PageSize)
                    .Take(ticketQueryDTO.PageSize)
                    .Select(f => new TicketQueryResultDTO
                    {
                        FlightNumber = f.FlightNumber,
                        Price = f.Price,
                        Date = f.DepartureDate.Date,
                    }).ToList();

                return Ok(outputList);
            }
            catch (Exception ex)
            {


                _response.IsSuccess = false;
                _response.Status = "Fail";
                _response.ErrorMessage = ex.ToString();

            }
            return _response;

        }



    }
}
