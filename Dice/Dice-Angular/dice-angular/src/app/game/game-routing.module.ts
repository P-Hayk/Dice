import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GameComponent } from "app/game/game.component";


const GameRoutes: Routes = [
    {
        path: '',
        component: GameComponent,
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forChild(GameRoutes)],
    exports: [RouterModule]
})

export class GameRoutingModule { }