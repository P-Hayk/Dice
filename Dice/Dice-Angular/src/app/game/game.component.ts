import { Component, OnInit, Input } from '@angular/core';
import { SignalR, BroadcastEventListener, SignalRConnection, ISignalRConnection } from "ng2-signalr";
import { GameRequestService } from "app/shared/game.request.service";
import { ActivatedRoute, Router } from '@angular/router';
import { StepRequestService } from 'app/shared/step.request.service';
import { SignalRService } from 'app/shared/signalR.service';
import { DataService } from 'app/shared/data.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html'
})
export class GameComponent implements OnInit {
  game: any;
  constructor(
    private SignalRService: SignalRService,
    private stepRequest: StepRequestService,
    private route: ActivatedRoute,
    private DataService: DataService

  ) {
    this.SignalRService.Connection.then(x => {
      x.listenFor('game1').subscribe(x => { this.game = x; });
      x.listenFor('animate').subscribe(x => {
        this.test(x);
      });
    })

  }

  ngOnInit() {
    this.game = this.DataService.value().ResponseObject;
  }

  firstdice = '';
  secondice = '';
  roleDice() {
    let data = {
      GameId: this.game.Id,
      PlayerId: +localStorage.getItem('Id')
    };

    this.stepRequest.roleDice(data).subscribe(x => {

      this.animateDice(x.ResponseObject.FirstDice, x.ResponseObject.SecondDice)
    });


  }

  animateDice(x, y) {
    setTimeout(() => { this.firstdice = "dice_t"; this.secondice = "dice_e" }, 200);
    setTimeout(() => { this.firstdice = "dice_s"; this.secondice = "dice_s" }, 400);
    setTimeout(() => { this.firstdice = "dice_e"; this.secondice = "dice_t" }, 600);
    setTimeout(() => { this.firstdice = `dice_${x}`; this.secondice = `dice_${y}` }, 800);
  }
  test(x) {
    this.animateDice(x.FirstDice, x.SecondDice);
  }
}
