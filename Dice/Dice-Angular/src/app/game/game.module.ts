import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { GameComponent } from "app/game/game.component";
import { GameRoutingModule } from "app/game/game-routing.module";
import { SignalRModule } from 'ng2-signalr';
import { SignalRConfiguration, SignalRConnection } from 'ng2-signalr';
import { GameRequestService } from "app/shared/game.request.service";

// v2.0.0
export function createConfig(): SignalRConfiguration {
    const c = new SignalRConfiguration();
    c.hubName = 'gameHub';
    c.url = "http://localhost:52944/signalr";
    c.jsonp = true;
    c.logging = true;
    return c;
}
@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        GameRoutingModule,
        ReactiveFormsModule,
        SignalRModule.forRoot(createConfig)
    ],
    providers: [GameRequestService],
    declarations: [GameComponent]
})
export class GameModule {

    
}
