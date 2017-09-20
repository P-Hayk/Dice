import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from "app/app-routing.module";
import { ApiRequestService } from "app/shared/api.request.service";
import { CookieService } from "angular2-cookie/services";
import { SignalRService } from "app/shared/signalR.service";
import { SignalRConfiguration, SignalRModule } from "ng2-signalr";
import { DataService } from 'app/shared/data.service';

// v2.0.0
export function createConfig(): SignalRConfiguration {
  const c = new SignalRConfiguration();
  c.hubName = 'gameHub';
  c.url = "http://localhost:52945/signalr";
  c.jsonp = true;
  c.logging = true;
  return c;
}
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    SignalRModule.forRoot(createConfig)
  ],
  providers: [ApiRequestService,CookieService,SignalRService,DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
