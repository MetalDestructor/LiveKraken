import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogRegisterData } from './dialog-register-data';

@Component({
  selector: 'app-kraken-register',
  templateUrl: './kraken-register.component.html',
  styleUrls: ['./kraken-register.component.css']
})
export class KrakenRegisterComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<KrakenRegisterComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogRegisterData) {}

  ngOnInit() {
  }

}
