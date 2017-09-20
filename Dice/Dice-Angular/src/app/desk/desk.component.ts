import { Component, OnInit } from '@angular/core';
import { SignalR, BroadcastEventListener, SignalRConnection, ISignalRConnection } from "ng2-signalr";
import { GameRequestService } from "app/shared/game.request.service";
import { ActivatedRoute, Router } from '@angular/router';
import { SignalRService } from "app/shared/signalR.service";
import { DataService } from 'app/shared/data.service';

@Component({
  selector: 'app-desk',
  templateUrl: './desk.component.html'
})
export class DeskComponent implements OnInit {

  con: ISignalRConnection;
  constructor(
    private SignalRService: SignalRService,
    private GameRequestService: GameRequestService,
    private route: Router,
    private DataService: DataService
  ) {
    this.SignalRService.Connection.then(x => {
      x.listenFor("game").subscribe(x => { this.games.push(x); });
    }
    )
  }
  games: any = [];

  ngOnInit() {
  }

  createGame() {

    let data =
      {
        FirstPlayerId: +localStorage.getItem('Id')
      }
    this.GameRequestService.createGame(data).subscribe(result => {
      this.DataService.setValue(result);
    
      this.route.navigate(["game"])
    });
  }

  joinToGame(game) {
    game.SecondPlayerID = +localStorage.getItem('Id');
    this.GameRequestService.joinToGame(game).subscribe(result => {
      this.DataService.setValue(result);
      this.route.navigate(["game"])
    });
  }

}
