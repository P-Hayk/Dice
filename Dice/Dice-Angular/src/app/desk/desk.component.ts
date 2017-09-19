import { Component, OnInit } from '@angular/core';
import { SignalR, BroadcastEventListener, SignalRConnection, ISignalRConnection } from "ng2-signalr";
import { GameRequestService } from "app/shared/game.request.service";
import { ActivatedRoute, Router } from '@angular/router';
import { SignalRService } from "app/shared/signalR.service";

@Component({
  selector: 'app-desk',
  templateUrl: './desk.component.html'
})
export class DeskComponent implements OnInit {

  con: ISignalRConnection;
  constructor(
    private SignalRService: SignalRService,
    private GameRequestService: GameRequestService,
    private route: Router
  ) {
  this.con = this.SignalRService.Connection;
    console.log('ctor');
   
  }
  games: any = [];

  ngOnInit() {
    console.log(this.con);
    this.con.listenFor("game").subscribe(x => { this.games.push(x), console.log(x) });

  }
  createGame() {

    let data =
      {
        FirstPlayerId: localStorage.getItem('Id')
      }
    this.GameRequestService.createGame(data).subscribe(result => this.route.navigate(["game"]));
  }

  joinToGame(game) {

    //this.SignalRService.value().listenFor("game1").subscribe(x => console.log(x)); 

    game.SecondPlayerID = +localStorage.getItem('Id');
    this.GameRequestService.joinToGame(game).subscribe(result => this.route.navigate(["game"]));

  }

}
