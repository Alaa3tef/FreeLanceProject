import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccidentFormComponent } from './accident-form/accident-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS ,HttpClient} from '@angular/common/http';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { StopcardComponent } from './stopcard/stopcard.component';
import { ReportAccidentComponent } from './report-accident/report-accident.component';
import { StopCardReportComponent } from './stop-card-report/stop-card-report.component';
import { StopcardTableComponent } from './stopcard-table/stopcard-table.component';
import { AccidentTableComponent } from './accident-table/accident-table.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { JMPFormComponent } from './jmpform/jmpform.component';
import { JMPTableComponent } from './jmptable/jmptable.component';
import { JMPReportComponent } from './jmpreport/jmpreport.component';
import { EditAccidentComponent } from './edit-accident/edit-accident.component';
import { AddAccidentCausesComponent } from './add-accident-causes/add-accident-causes.component';
import { AccidentCausesComponent } from './accident-causes/accident-causes.component';
import { AddClassificationComponent } from './add-classification/add-classification.component';
import { ClassificationsComponent } from './classifications/classifications.component';
import { ClassificationOfAccidentComponent } from './classification-of-accident/classification-of-accident.component';
import { AddclassificationOfAccdComponent } from './addclassification-of-accd/addclassification-of-accd.component';
import { AddComminucationMethodComponent } from './add-comminucation-method/add-comminucation-method.component';
import { ComminucationMethodComponent } from './comminucation-method/comminucation-method.component';
import { DriverComponent } from './driver/driver.component';
import { AddDriverComponent } from './add-driver/add-driver.component';
import { AddPassengersComponent } from './add-passengers/add-passengers.component';
import { PassengersComponent } from './passengers/passengers.component';
import { PreventionCategoriesComponent } from './prevention-categories/prevention-categories.component';
import { AddPreventionCategoriesComponent } from './add-prevention-categories/add-prevention-categories.component';
import { AddQHSEPositionsComponent } from './add-qhsepositions/add-qhsepositions.component';
import { QHSEPositionsComponent } from './qhsepositions/qhsepositions.component';
import { QHSENamesComponent } from './qhsenames/qhsenames.component';
import { AddQHSENamesComponent } from './add-qhsenames/add-qhsenames.component';
import { AddReportedByNamesComponent } from './add-reported-by-names/add-reported-by-names.component';
import { ReportedByNamesComponent } from './reported-by-names/reported-by-names.component';
import { ReportedByPositionsComponent } from './reported-by-positions/reported-by-positions.component';
import { AddReportedByPositionsComponent } from './add-reported-by-positions/add-reported-by-positions.component';
import { AddRigsComponent } from './add-rigs/add-rigs.component';
import { RigsComponent } from './rigs/rigs.component';
import { RouteNamesComponent } from './route-names/route-names.component';
import { AddRouteNamesComponent } from './add-route-names/add-route-names.component';
import { AddToolPusherPositionsComponent } from './add-tool-pusher-positions/add-tool-pusher-positions.component';
import { ToolPusherPositionsComponent } from './tool-pusher-positions/tool-pusher-positions.component';
import { ToolPusherNamesComponent } from './tool-pusher-names/tool-pusher-names.component';
import { AddToolPusherNamesComponent } from './add-tool-pusher-names/add-tool-pusher-names.component';
import { AddTypeofInjuriesComponent } from './add-typeof-injuries/add-typeof-injuries.component';
import { TypeofInjuriesComponent } from './typeof-injuries/typeof-injuries.component';
import { TypeofObserviationComponent } from './typeof-observiation/typeof-observiation.component';
import { AddTypeofObserviationComponent } from './add-typeof-observiation/add-typeof-observiation.component';
import { AddVehiclesComponent } from './add-vehicles/add-vehicles.component';
import { VehiclesComponent } from './vehicles/vehicles.component';
import { ViolationCategoriesComponent } from './violation-categories/violation-categories.component';
import { AddViolationCategoriesComponent } from './add-violation-categories/add-violation-categories.component';
import { EditStopCardComponent } from './edit-stop-card/edit-stop-card.component';
import { EditAccidentCausesComponent } from './edit-accident-causes/edit-accident-causes.component';
import { EditClassificationComponent } from './edit-classification/edit-classification.component';
import { EditClassificationOfAccidentComponent } from './edit-classification-of-accident/edit-classification-of-accident.component';
import { EditComminucationMethodComponent } from './edit-comminucation-method/edit-comminucation-method.component';
import { EditDriverComponent } from './edit-driver/edit-driver.component';
import { EditPassengerComponent } from './edit-passenger/edit-passenger.component';
import { EditPreventionCategoryComponent } from './edit-prevention-category/edit-prevention-category.component';
import { EditQHSEPositionComponent } from './edit-qhseposition/edit-qhseposition.component';
import { EditQHSEPositionNameComponent } from './edit-qhseposition-name/edit-qhseposition-name.component';
import { EditReportedByNameComponent } from './edit-reported-by-name/edit-reported-by-name.component';
import { EditReportedByPositionComponent } from './edit-reported-by-position/edit-reported-by-position.component';
import { EditRigComponent } from './edit-rig/edit-rig.component';
import { EditRouteNameComponent } from './edit-route-name/edit-route-name.component';
import { EditToolPusherPositionComponent } from './edit-tool-pusher-position/edit-tool-pusher-position.component';
import { EditToolPusherPositionNameComponent } from './edit-tool-pusher-position-name/edit-tool-pusher-position-name.component';
import { EditTypeOfInjuryComponent } from './edit-type-of-injury/edit-type-of-injury.component';
import { EditTypeOfObservationCategoryComponent } from './edit-type-of-observation-category/edit-type-of-observation-category.component';
import { EditVehicleComponent } from './edit-vehicle/edit-vehicle.component';
import { EditViolationCategoryComponent } from './edit-violation-category/edit-violation-category.component';
import { EditJMLFormComponent } from './edit-jmlform/edit-jmlform.component';
import { TokenInterceptorService } from 'Services/token-interceptor.service';
import { ChangepasswordComponent } from './changepassword/changepassword.component';
import { StopCardChartComponent } from './stop-card-chart/stop-card-chart.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { ArrivalStatusSJPComponent } from './arrival-status-sjp/arrival-status-sjp.component';
import { SJPTodayComponent } from './sjptoday/sjptoday.component';
import { StopCardCompareChartComponent } from './stop-card-compare-chart/stop-card-compare-chart.component';
import { HeathComponent } from './heath/heath.component';
import { SafetyComponent } from './safety/safety.component';
import { EnvironmentComponent } from './environment/environment.component';
import { QualityComponent } from './quality/quality.component';
import { ClincFormsComponent } from './clinc-forms/clinc-forms.component';
import { QSHEFormsComponent } from './qsheforms/qsheforms.component';
import { PolicyComponent } from './policy/policy.component';
import { RigMovePerformanceEvaluationComponent } from './rig-move-performance-evaluation/rig-move-performance-evaluation.component';
import { AddRigMovePerformanceEvaluationComponent } from './add-rig-move-performance-evaluation/add-rig-move-performance-evaluation.component';
import { EditRigMovePerformanceEvaluationComponent } from './edit-rig-move-performance-evaluation/edit-rig-move-performance-evaluation.component';
import { PrintRigPerformanceComponent } from './print-rig-performance/print-rig-performance.component';
import { RigPerformanceChartComponent } from './rig-performance-chart/rig-performance-chart.component';
import { SubDashboardComponent } from './sub-dashboard/sub-dashboard.component';
import { RigPerformanceCompareChartsComponent } from './rig-performance-compare-charts/rig-performance-compare-charts.component';
import { AddPTSMComponent } from './add-ptsm/add-ptsm.component';
import { PTSMComponent } from './ptsm/ptsm.component';
import { EditPTSMComponent } from './edit-ptsm/edit-ptsm.component';
import { PrintPTSMComponent } from './print-ptsm/print-ptsm.component';
import { BOPComponent } from './bop/bop.component';
import { EditBOPComponent } from './edit-bop/edit-bop.component';
import { BopTableComponent } from './bop-table/bop-table.component';
import { PrintBopComponent } from './print-bop/print-bop.component';

@NgModule({
  declarations: [

    AppComponent,
    AccidentFormComponent,
    NavbarComponent,
    FooterComponent,
    SidebarComponent,
    HomeComponent,
    PageNotFoundComponent,
    StopcardComponent,
    ReportAccidentComponent,
    StopCardReportComponent,
    StopcardTableComponent,
    AccidentTableComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    ProfileComponent,
    ContactUsComponent,
    JMPFormComponent,
    JMPTableComponent,
    JMPReportComponent,
    EditAccidentComponent,
    AddAccidentCausesComponent,
    AccidentCausesComponent,
    AddClassificationComponent,
    ClassificationsComponent,
    ClassificationOfAccidentComponent,
    AddclassificationOfAccdComponent,
    AddComminucationMethodComponent,
    ComminucationMethodComponent,
    DriverComponent,
    AddDriverComponent,
    AddPassengersComponent,
    PassengersComponent,
    PreventionCategoriesComponent,
    AddPreventionCategoriesComponent,
    AddQHSEPositionsComponent,
    QHSEPositionsComponent,
    QHSENamesComponent,
    AddQHSENamesComponent,
    AddReportedByNamesComponent,
    ReportedByNamesComponent,
    ReportedByPositionsComponent,
    AddReportedByPositionsComponent,
    AddRigsComponent,
    RigsComponent,
    RouteNamesComponent,
    AddRouteNamesComponent,
    AddToolPusherPositionsComponent,
    ToolPusherPositionsComponent,
    ToolPusherNamesComponent,
    AddToolPusherNamesComponent,
    AddTypeofInjuriesComponent,
    TypeofInjuriesComponent,
    TypeofObserviationComponent,
    AddTypeofObserviationComponent,
    AddVehiclesComponent,
    VehiclesComponent,
    ViolationCategoriesComponent,
    AddViolationCategoriesComponent,
    EditStopCardComponent,
    EditAccidentCausesComponent,
    EditClassificationComponent,
    EditClassificationOfAccidentComponent,
    EditComminucationMethodComponent,
    EditDriverComponent,
    EditPassengerComponent,
    EditPreventionCategoryComponent,
    EditQHSEPositionComponent,
    EditQHSEPositionNameComponent,
    EditReportedByNameComponent,
    EditReportedByPositionComponent,
    EditRigComponent,
    EditRouteNameComponent,
    EditToolPusherPositionComponent,
    EditToolPusherPositionNameComponent,
    EditTypeOfInjuryComponent,
    EditTypeOfObservationCategoryComponent,
    EditVehicleComponent,
    EditViolationCategoryComponent,
    EditJMLFormComponent,
    ChangepasswordComponent,
    StopCardChartComponent,
    NotificationsComponent,
    ArrivalStatusSJPComponent,
    SJPTodayComponent,
    StopCardCompareChartComponent,
    HeathComponent,
    SafetyComponent,
    EnvironmentComponent,
    QualityComponent,
    ClincFormsComponent,
    QSHEFormsComponent,
    PolicyComponent,
    RigMovePerformanceEvaluationComponent,
    AddRigMovePerformanceEvaluationComponent,
    EditRigMovePerformanceEvaluationComponent,
    PrintRigPerformanceComponent,
    RigPerformanceChartComponent,
    SubDashboardComponent,
    RigPerformanceCompareChartsComponent,
    AddPTSMComponent,
    PTSMComponent,
    EditPTSMComponent,
    PrintPTSMComponent,
    BOPComponent,
    EditBOPComponent,
    BopTableComponent,
    PrintBopComponent,


  ],
  imports: [
    BrowserModule,
    Ng2SearchPipeModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],

  providers: [{provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptorService,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
