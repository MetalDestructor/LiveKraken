import {
  Component,
  OnInit,
  ElementRef,
  ViewChild,
  OnDestroy
} from "@angular/core";
import videojs from "video.js";
import { ActivatedRoute } from "@angular/router";
import { Stream } from "../kraken-browse/stream.model";
import { StreamService } from "./stream.service";
import { Subscription } from 'rxjs';

@Component({
  selector: "app-kraken-stream",
  templateUrl: "./kraken-stream.component.html",
  styleUrls: ["./kraken-stream.component.css"]
})
export class KrakenStreamComponent implements OnInit, OnDestroy {
  @ViewChild("video", { static: true }) videoElement: ElementRef;
  video: any;
  stream: Stream;
  subscription: Subscription;

  constructor(
    private route: ActivatedRoute,
    private streamService: StreamService
  ) {}

  ngOnInit() {
    const username = this.route.snapshot.params.id;
    console.log(username);
    this.subscription = this.streamService.getStream(username).subscribe(data => {
      console.log(data);
      this.stream = data as Stream;
    });
    console.log(this.stream);
    this.video = videojs(this.videoElement.nativeElement);
    this.video.src({
      src: "http://localhost:8080/hls/random.m3u8",
      type: "application/x-mpegURL"
    });
    this.video.play();
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }
}
