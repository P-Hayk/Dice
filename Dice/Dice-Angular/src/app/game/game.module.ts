import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ApiRequestService } from "app/shared/api.request.service";
import { GameComponent } from "app/game/game.component";
import { GameRoutingModule } from "app/game/game-routing.module";


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        GameRoutingModule,
        ReactiveFormsModule
    ],
    providers:[],
    declarations: [GameComponent]
})

export class GameModule { }