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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpHeaders } from '@angular/common/http';
import { fakeBackendProvider } from './_helpers/fake-backend';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { LigandComponent } from './create-calculation/ligand/ligand.component';
import { ReceptorComponent } from './create-calculation/receptor/receptor.component';
import { CreateNewAccountComponent } from './create-new-account/create-new-account.component';
import { CalcPartialViewComponent } from './view-calculations/calc-partial-view/calc-partial-view.component';
import { NanoparticleDetailsComponent } from './shared/nanoparticle-details/nanoparticle-details.component';
import { ResultsPartialComponent } from './results/results-partial/results-partial.component';
import { ResultsLigandPartialComponent } from './results/results-ligand-partial/results-ligand-partial.component';
import { ResultsReceptorPartialComponent } from './results/results-receptor-partial/results-receptor-partial.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateCalculationComponent,
    LoginComponent,
    ViewCalculationsComponent,
    ResultsComponent,
    NavComponent,
    LigandComponent,
    ReceptorComponent,
    CreateNewAccountComponent,
    CalcPartialViewComponent,
    NanoparticleDetailsComponent,
    ResultsPartialComponent,
    ResultsLigandPartialComponent,
    ResultsReceptorPartialComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatFormFieldModule,
    MatExpansionModule,
    MatSlideToggleModule,
    MatCheckboxModule,
    MatProgressSpinnerModule,
    LoggerModule.forRoot({
      serverLoggingUrl: environment.apiUrl + '/api/log',
      level: NgxLoggerLevel.TRACE,
      serverLogLevel: NgxLoggerLevel.ERROR,
      disableConsoleLogging: environment.production
    })
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    fakeBackendProvider,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
