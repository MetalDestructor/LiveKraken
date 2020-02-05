import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { environment } from "src/environments/environment";

@Injectable({ providedIn: "root" })
export class BrowseService {
  path: string;
  constructor(private http: HttpClient, private router: Router) {
    this.path = environment.path;
  }

  getStreams() {
    return this.http.get(this.path + "/browse");
  }

  getOnlineStreams() {
    return this.http.get(this.path + "/browse/online");
  }
}
