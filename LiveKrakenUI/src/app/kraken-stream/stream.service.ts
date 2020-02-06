import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { environment } from "src/environments/environment";

@Injectable({ providedIn: "root" })
export class StreamService {
  path: string;
  constructor(private http: HttpClient, private router: Router) {
    this.path = environment.path;
  }

  getStream(username: string) {
    return this.http.get(this.path + "/stream/" + username);
  }
}
