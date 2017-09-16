import { Component, OnInit, Input } from '@angular/core';
import { SignalR, BroadcastEventListener, SignalRConnection, ISignalRConnection } from "ng2-signalr";
import { GameRequestService } from "app/shared/game.request.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html'
})
export class GameComponent implements OnInit {


  constructor(private _signalR: SignalR) {
    
   }

  ngOnInit() {

  }

}
