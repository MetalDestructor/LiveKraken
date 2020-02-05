import { Component, OnInit } from '@angular/core';
import { BrowseService } from './browse.service';
import { Stream } from './stream.model';

@Component({
  selector: 'app-kraken-browse',
  templateUrl: './kraken-browse.component.html',
  styleUrls: ['./kraken-browse.component.css']
})
export class KrakenBrowseComponent implements OnInit {
  streams: Stream[];

  constructor(public browseService: BrowseService) { }

  ngOnInit() {
    this.browseService.getStreams().subscribe(res => {
      this.streams = <Stream[]>res;
    });
  }



}
