using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using se4458_midterm.Models;
using se4458_midterm.Models.Dto;
using se4458_midterm.Source.Svc;
using System.Net;
using System.Transactions;

namespace se4458_midterm.Controllers.v2
{
    [Route("api/v{version:apiVersion}/Flightv2")]
    [ApiController]
    [ApiVersion("2.0")]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;
        private IMapper _mapper;
        protected APIResponse _response;

        public FlightController(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _response = new();
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<APIResponse> GetAllFlights()
        {

            IEnumerable<Flight> flightList = _flightService.GetAllFlights();
            _response.Result = _mapper.Map<List<FlightDTO>>(flightList);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }


        [HttpGet("{flightNumber}", Name = "GetFlightByNumber")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<APIResponse> GetFlightV2(int flightNumber)
        {

            try
            {


                if (flightNumber == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Status = "Fail";
                    return BadRequest(_response);
                }

                var flight = _flightService.GetFlightByNumber(flightNumber);
                if (flight == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.Status = "Fail";

                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<FlightDTO>(flight);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Status = "Fail";
                _response.ErrorMessage = ex.ToString();

            }
            return _response;
        }


        [HttpPost("CreateFlight")]
        [Authorize(Roles = "admin")]
        public ActionResult<APIResponse> CreateFlight([FromBody] FlightDTO flight)
        {

            FlightResultDto ret = new FlightResultDto();
            if (!ModelState.IsValid)
            {
                ret.Result = "FAILURE";
                ret.ErrorMessage = "Invalid Model";
                ret.IsSuccess = false;
                _response.Status = "Fail";
                return ret;
            }

            try
            {
                Flight createdFlight = _mapper.Map<Flight>(flight);

                int cnt = _flightService.CreateFlight(createdFlight);
                if (cnt > 0)
                {
                    ret.Id = _flightService.GetFlightByNumber(createdFlight.FlightNumber).Id;
                }
            }
            catch (Exception ex)
            {
                ret.Result = "FAILURE";
                ret.ErrorMessage = ex.Message;
                ret.IsSuccess = false;
                _response.Status = "Fail";
            }
            return ret;

        }

        [HttpPut("{flightNumber:int}", Name = "UpdateFlightByFlightNumber")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateFlight(int flightNumber, [FromBody] FlightDTO flightDTO)
        {
            if (flightDTO == null || flightNumber != flightDTO.FlightNumber)
            {
                return BadRequest("Invalid request. Check the provided data and try again.");
            }

            try
            {
                Flight existingFlight = _flightService.GetFlightByNumber(flightNumber);

                if (existingFlight == null)
                {
                    _response.IsSuccess = false;
                    _response.Status = "Fail";
                    return NotFound($"Flight with no {flightNumber} not found.");
                }


                _mapper.Map(flightDTO, existingFlight);

                _flightService.UpdateFlight(existingFlight);

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating the flight: {ex.Message}");
            }
        }

        [HttpDelete("{flightNumber:int}", Name = "DeleteFlightByNumber")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> DeleteFlight(int flightNumber)
        {
            APIResponse response = new APIResponse();

            try
            {
                if (flightNumber == 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.ErrorMessage = "Invalid Flight no provided.";
                    _response.IsSuccess = false;
                    _response.Status = "Fail";
                    return BadRequest(response);
                }

                var flight = _flightService.GetFlightByNumber(flightNumber);

                if (flight == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.ErrorMessage = $"Flight with no {flightNumber} not found.";
                    _response.IsSuccess = false;
                    _response.Status = "Fail";
                    return NotFound(response);
                }

                _flightService.Remove(flight);

                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;

                _response.Status = "Fail";
                return BadRequest(response);
            }
        }


    }
}
