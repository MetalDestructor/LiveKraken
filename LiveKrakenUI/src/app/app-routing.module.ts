import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { KrakenBrowseComponent } from './kraken-browse/kraken-browse.component';
import { KrakenStreamComponent } from './kraken-stream/kraken-stream.component';


const routes: Routes = [
  {path: '', component: KrakenBrowseComponent},
  {path: 'stream/:id', component: KrakenStreamComponent},
  {path: 'browse', component: KrakenBrowseComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
