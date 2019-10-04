import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { CreateCalculationComponent } from './create-calculation/create-calculation.component';
import { LoginComponent } from './login/login.component';
import { ViewCalculationsComponent } from './view-calculations/view-calculations.component';
import { ResultsComponent } from './results/results.component';
import { FormsModule } from '@angular/forms';
import { Result } from 'src/models/result';

@NgModule({
  declarations: [
    AppComponent,
    CreateCalculationComponent,
    LoginComponent,
    ViewCalculationsComponent,
    ResultsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    FormsModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
