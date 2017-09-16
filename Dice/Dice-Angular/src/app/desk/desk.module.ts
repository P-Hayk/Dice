import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DeskComponent } from "app/desk/desk.component";
import { DeskRoutingModule } from "app/desk/desk-routing.module";
import { SignalRModule } from 'ng2-signalr';
import { SignalRConfiguration, SignalRConnection } from 'ng2-signalr';
import { GameRequestService } from "app/shared/game.request.service";


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        DeskRoutingModule,
        ReactiveFormsModule,
        
    ],
    providers: [GameRequestService],
    declarations: [DeskComponent]
})
export class DeskModule {

    
}
