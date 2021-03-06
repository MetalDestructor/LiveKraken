﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveKraken.DataServices.Interfaces;
using LiveKraken.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LiveKraken.API.Controllers
{
    [Route("api")]
    public class StreamController : Controller
    {
        private readonly IStreamService streamService;
        public StreamController(IStreamService streamService)
        {
            this.streamService = streamService ?? throw new ArgumentNullException("streamService");
        }

        [HttpGet("browse")]
        public async Task<IActionResult> GetStreams()
        {
            try
            {
                var streamsDto = await this.streamService.GetStreams();
                return Ok(streamsDto);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Server Error on getting streams.");
            }

        }

        [HttpGet("browse/online")]
        public async Task<IActionResult> GetOnlineStreams()
        {
            try
            {
                var streamsDto = await this.streamService.GetOnlineStreams();
                return Ok(streamsDto);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Server Error on getting online streams.");
            }

        }

        [HttpGet("stream/{username}")]
        public async Task<IActionResult> GetStream(string username)
        {
            try
            {
                var streamDto = await this.streamService.GetStream(username);
                return Ok(streamDto);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Server Error on getting online streams.");
            }

        }

        [HttpPut("status")]
        public async Task<IActionResult> ChangeStatus([FromBody]StatusDto stream)
        {
            try
            {
                await this.streamService.ChangeStatus(stream.Id);
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Server Error on changing the status of stream with id " + stream.Id);
            }

        }
    }
}
