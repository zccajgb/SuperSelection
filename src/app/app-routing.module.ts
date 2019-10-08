import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResultsComponent } from './results/results.component';
import { LoginComponent } from './login/login.component';
import { ViewCalculationsComponent } from './view-calculations/view-calculations.component';
import { CreateCalculationComponent } from './create-calculation/create-calculation.component';
import { AuthGuard } from './_helpers/auth.guard';
import { CreateNewAccountComponent } from './create-new-account/create-new-account.component';


const routes: Routes = [
  { path: '', redirectTo: '/view-calculations', pathMatch: 'full'},
  { path: 'login', component: LoginComponent},
  { path: 'create-new-account', component: CreateNewAccountComponent},
  { path: 'view-calculations', component: ViewCalculationsComponent, canActivate: [AuthGuard] },
  { path: 'results', component: ResultsComponent, canActivate: [AuthGuard] },
  { path: 'create-calculation', component: CreateCalculationComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
