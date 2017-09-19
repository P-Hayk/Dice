import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RegistrationComponent } from './registration.component';
import { RegistrationRoutingModule } from './Registration-routing.module';
import { ApiRequestService } from "app/shared/api.request.service";
import { PlayerRequestService } from "app/shared/player.request.service";


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        RegistrationRoutingModule,
        ReactiveFormsModule
    ],
    providers:[PlayerRequestService],
    declarations: [RegistrationComponent]
})

export class RegistrationModule { }