import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResultsComponent } from './results/results.component';
import { LoginComponent } from './login/login.component';
import { ViewCalculationsComponent } from './view-calculations/view-calculations.component';
import { CreateCalculationComponent } from './create-calculation/create-calculation.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent},
  { path: 'viewCalculations', component: ViewCalculationsComponent },
  { path: 'results', component: ResultsComponent },
  { path: 'createCalculation', component: CreateCalculationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
