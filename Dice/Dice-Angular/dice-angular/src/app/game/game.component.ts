import { Component, OnInit } from '@angular/core';
import { SignalR, BroadcastEventListener, SignalRConnection, ISignalRConnection } from "ng2-signalr";
import { GameRequestService } from "app/shared/game.request.service";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html'
})
export class GameComponent implements OnInit {


  constructor(
    private _signalR: SignalR,
    private GameRequestService: GameRequestService
  ) { }
  games: any = [];
  connection: ISignalRConnection;
  ngOnInit() {

    this._signalR.connect(
      {
        qs: {
          'uid': localStorage.getItem('Id')
        }
      })
      .then(
      c => {
        this.connection = c;
        c.listenFor("game").subscribe(x => this.games.push(x));
        c.listenFor("game1").subscribe(x => console.log(x));
      });

  }
  createGame() {
   
    let data =
      {
        FirstPlayerId: localStorage.getItem('Id')
      }
    this.GameRequestService.createGame(data).subscribe();
  }
  joinToGame(game) {
      console.log(game);
    game.SecondPlayerID = +localStorage.getItem('Id');
    this.GameRequestService.joinToGame(game).subscribe();
    
  }

}
