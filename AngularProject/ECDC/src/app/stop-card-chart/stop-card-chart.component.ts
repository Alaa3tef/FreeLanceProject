import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { Chart, registerables } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';
Chart.register(ChartDataLabels);
Chart.register(...registerables);

@Component({
  selector: 'app-stop-card-chart',
  templateUrl: './stop-card-chart.component.html',
  styleUrls: ['./stop-card-chart.component.scss'],
})

export class StopCardChartComponent {
  clearChart(ID_Name:string) {
    const myElement = document.querySelector('#'+ ID_Name) as HTMLElement;
    myElement.remove()
    this.UnsafeAct=[]
    this.UnsafeCondition=[]
    this.PositiveRemark=[]
    this.Other=[]
    this.BypassingSafetyControls = []
    this.Driving = []
    this.EnergyIsolation = []
    this.HotWork = []
    this.LineofFire = []
    this.SafeMechanicalLifting = []
    this.WorkAuthorization = []
    this.WorkingatHeight = []
    this.PPE = []
    this.Housekeeping = []
    this.Environmental = []
    this.HealthCare = [];
    this.SafetyProtectionSystem = []
    this.HSEIMS= []
    this.Equipment = []
    this.OtherCategory= []
    this.SWA_yes = []
    this.SWA_no = []
  }

  AddCanvas(ID_Name:string,DIV_Name:string) {
    // Create a new element
    var newElement = document.createElement('canvas');
    newElement.id=ID_Name

    // Get the parent element where you want to append the new element
    const myElement = document.querySelector('#'+DIV_Name) as HTMLElement;

    // Append the new element to the parent element
    myElement.appendChild(newElement);
  }

  temp: boolean = false;
  classifications: string[] = [];
  categories: string[] = [];
  UnsafeAct: any[] = [];
  UnsafeActCount: number = 0;
  UnsafeCondition: any[] = [];
  UnsafeConditionCount: number = 0;
  PositiveRemark: any[] = [];
  PositiveRemarkCount: number = 0;
  Other: any[] = [];
  OtherCount: number = 0;
  BypassingSafetyControls: any[] = [];
  BypassingSafetyControlsCount: number = 0;
  Driving: any[] = [];
  DrivingCount: number = 0;
  EnergyIsolation: any[] = [];
  EnergyIsolationCount: number = 0;
  HotWork: any[] = [];
  HotWorkCount: number = 0;
  LineofFire: any[] = [];
  LineofFireCount: number = 0;
  SafeMechanicalLifting: any[] = [];
  SafeMechanicalLiftingCount: number = 0;
  WorkAuthorization: any[] = [];
  WorkAuthorizationCount: number = 0;
  WorkingatHeight: any[] = [];
  WorkingatHeightCount: number = 0;
  PPE: any[] = [];
  PPECount: number = 0;
  Housekeeping: any[] = [];
  HousekeepingCount: number = 0;
  Environmental: any[] = [];
  EnvironmentalCount: number = 0;
  HealthCare: any[] = [];
  HealthCareCount: number = 0;
  SafetyProtectionSystem: any[] = [];
  SafetyProtectionSystemCount: number = 0;
  HSEIMS: any[] = [];
  HSEIMSCount: number = 0;
  Equipment: any[] = [];
  EquipmentCount: number = 0;
  OtherCategory: any[] = [];
  OtherCategoryCount: number = 0;
  SWA_yes: any[] = [];
  SWA_yesCount: number = 0;
  SWA_no: any[] = [];
  SWA_noCount: number = 0;

  User:any;

  constructor(private loginService:LoginService,private dataService: DataService) {}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User=this.loginService.currentUser.getValue();
    this.dataService.GetClassification().subscribe({
      next: data => {
        data.data.forEach((element: { name: string; }) => {
          this.classifications.push(element.name)
        });
      }
    })
    this.dataService.GetTypeOfObservationCategory().subscribe({
      next: data => {
        data.data.forEach((element: { name: string; }) => {
          this.categories.push(element.name)
        });
      }
    })
  }


  onChange(event: any) {
    console.log("event")
    console.log(event)
    const myComboBox = document.getElementById('month') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.temp = true;
    this.dataService.GetStopCardsByMonth(event.target.value,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart")
        data.data.forEach((element: { classification: string; }) => {
          if (element.classification == 'Unsafe Act') {
            this.UnsafeAct.push(element)
          }
          else if (element.classification == 'Positive Remark') {
            this.PositiveRemark.push(element)
          }
          else if (element.classification == 'Unsafe Condition') {
            this.UnsafeCondition.push(element)
          }
          else {
            this.Other.push(element)
          }
        });
        this.UnsafeActCount = this.UnsafeAct.length
        this.UnsafeConditionCount = this.UnsafeCondition.length
        this.PositiveRemarkCount = this.PositiveRemark.length
        this.OtherCount = this.Other.length


        this.AddCanvas("myChart","chart1")

        var myChart = new Chart("myChart", {
          type: 'bar',
          data: {
            labels: this.classifications,
            datasets: [{
              label: selectedText,
              data: [this.UnsafeActCount, this.UnsafeConditionCount, this.PositiveRemarkCount, this.OtherCount],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)'
                ],
                font: {
                  size: 18,
                }
              }
            }]
          },
          options: {
            scales: {
              y: {
                beginAtZero: true
              }
            }
          }
        });
      }
    });

    this.dataService.GetStopCardsByMonth(event.target.value,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart2")

        data.data.forEach((element: { typeOfObservationCategory: string; }) => {
          if (element.typeOfObservationCategory == 'Bypassing Safety Controls') {
            this.BypassingSafetyControls.push(element)
          }
          else if (element.typeOfObservationCategory == 'Driving') {
            this.Driving.push(element)
          }
          else if (element.typeOfObservationCategory == 'Energy Isolation') {
            this.EnergyIsolation.push(element)
          }
          else if (element.typeOfObservationCategory == 'Hot Work') {
            this.HotWork.push(element)
          }
          else if (element.typeOfObservationCategory == 'Line of Fire') {
            this.LineofFire.push(element)
          }
          else if (element.typeOfObservationCategory == 'Safe Mechanical Lifting') {
            this.SafeMechanicalLifting.push(element)
          }
          else if (element.typeOfObservationCategory == 'Work Authorization') {
            this.WorkAuthorization.push(element)
          }
          else if (element.typeOfObservationCategory == 'Working at Height') {
            this.WorkingatHeight.push(element)
          }
          else if (element.typeOfObservationCategory == 'PPE') {
            this.PPE.push(element)
          }
          else if (element.typeOfObservationCategory == 'Housekeeping') {
            this.Housekeeping.push(element)
          }
          else if (element.typeOfObservationCategory == 'Environmental') {
            this.Environmental.push(element)
          }
          else if (element.typeOfObservationCategory == 'Health Care') {
            this.HealthCare.push(element)
          }
          else if (element.typeOfObservationCategory == 'Safety Protection System') {
            this.SafetyProtectionSystem.push(element)
          }
          else if (element.typeOfObservationCategory == 'HSE IMS') {
            this.HSEIMS.push(element)
          }
          else if (element.typeOfObservationCategory == 'Equipment') {
            this.Equipment.push(element)
          }
          else {
            this.OtherCategory.push(element)
          }
        });

        this.BypassingSafetyControlsCount = this.BypassingSafetyControls.length
        this.DrivingCount = this.Driving.length
        this.EnergyIsolationCount = this.EnergyIsolation.length
        this.HotWorkCount = this.HotWork.length
        this.LineofFireCount = this.LineofFire.length
        this.SafeMechanicalLiftingCount = this.SafeMechanicalLifting.length
        this.WorkAuthorizationCount = this.WorkAuthorization.length
        this.WorkingatHeightCount = this.WorkingatHeight.length
        this.PPECount = this.PPE.length
        this.HousekeepingCount = this.Housekeeping.length
        this.EnvironmentalCount = this.Environmental.length
        this.HealthCareCount = this.HealthCare.length
        this.SafetyProtectionSystemCount = this.SafetyProtectionSystem.length
        this.HSEIMSCount = this.HSEIMS.length
        this.EquipmentCount = this.Equipment.length
        this.OtherCategoryCount = this.OtherCategory.length

        this.AddCanvas("myChart2","chart2")

        var myChart2 = new Chart("myChart2", {
          type: 'bar',
          data: {
            labels: this.categories,
            datasets: [{
              label: selectedText,
              data: [
                this.BypassingSafetyControlsCount,
                this.DrivingCount,
                this.EnergyIsolationCount,
                this.HotWorkCount,
                this.LineofFireCount,
                this.SafeMechanicalLiftingCount,
                this.WorkAuthorizationCount,
                this.WorkingatHeightCount,
                this.PPECount,
                this.HousekeepingCount,
                this.EnvironmentalCount,
                this.HealthCareCount,
                this.SafetyProtectionSystemCount,
                this.HSEIMSCount,
                this.EquipmentCount,
                this.OtherCategoryCount
              ],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(255, 99, 237, 0.2)',
                'rgba(166, 99, 255, 0.2)',
                'rgba(99, 240, 255, 0.2)',
                'rgba(255, 202, 99, 0.2)',
                'rgba(166, 255, 99, 0.2)',
                'rgba(57, 9, 140, 0.2)',
                'rgba(10, 140, 9, 0.2)',
                'rgba(140, 84, 9, 0.2)',
                'rgba(158, 10, 147, 0.2)',
                'rgba(47, 4, 43, 0.2)',
                'rgba(12, 16, 151, 0.2)',
                'rgba(12, 151, 132, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(255, 99, 237, 1)',
                'rgba(166, 99, 255, 1)',
                'rgba(99, 240, 255, 1)',
                'rgba(255, 202, 99, 1)',
                'rgba(166, 255, 99, 1)',
                'rgba(57, 9, 140, 1)',
                'rgba(10, 140, 9, 1)',
                'rgba(140, 84, 9, 1)',
                'rgba(158, 10, 147, 1)',
                'rgba(47, 4, 43, 1)',
                'rgba(12, 16, 151, 1)',
                'rgba(12, 151, 132, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(255, 99, 237, 1)',
                  'rgba(166, 99, 255, 1)',
                  'rgba(99, 240, 255, 1)',
                  'rgba(255, 202, 99, 1)',
                  'rgba(166, 255, 99, 1)',
                  'rgba(57, 9, 140, 1)',
                  'rgba(10, 140, 9, 1)',
                  'rgba(140, 84, 9, 1)',
                  'rgba(158, 10, 147, 1)',
                  'rgba(47, 4, 43, 1)',
                  'rgba(12, 16, 151, 1)',
                  'rgba(12, 151, 132, 1)'
                ],
                font: {
                  size: 14,
                }
              }
            }]
          },
          options: {
            scales: {
              y: {
                beginAtZero: true
              }
            }
          }
        });

        myChart2.update();

      }
    });
    this.dataService.GetStopCardsByMonth(event.target.value,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart3")

        data.data.forEach((element: { stopWorkAuthorityApplied: string; }) => {
          if (element.stopWorkAuthorityApplied == 'Yes') {
            this.SWA_yes.push(element)
          }
          else if (element.stopWorkAuthorityApplied == 'No') {
            this.SWA_no.push(element)
          }
        });
        this.SWA_yesCount = this.SWA_yes.length
        this.SWA_noCount = this.SWA_no.length

        console.log("this.SWA_yesCount")
        console.log(this.SWA_yesCount)
        console.log("this.SWA_noCount")
        console.log(this.SWA_noCount)

        this.AddCanvas("myChart3","chart3")

        var myChart3 = new Chart("myChart3", {
          type: 'bar',
          data: {
            labels: ["Yes", "No"],
            datasets: [{
              label: selectedText,
              data: [this.SWA_yesCount, this.SWA_noCount],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                ],
                font: {
                  size: 18,
                }
              }
            }]
          },
          options: {
            scales: {
              y: {
                beginAtZero: true
              }
            }
          }
        });

        myChart3.update();

      }
    });

  }

  // clearChart(elementId: string) {
  //   if (document.getElementById(elementId)) {
  //     var charts = Chart.instances; // Get all chart instances
  //     console.log("charts*///******************")
  //     console.log(charts)
  //     for (var key in charts) { // loop looking for the chart you want to remove
  //       if (!charts.hasOwnProperty(key)) {
  //         continue;
  //       }
  //       var chartAux = Chart.instances[key];
  //       if (chartAux.ctx.canvas.id === elementId) {
  //         // Remove chart-legend before destroying the chart
  //         var parent = chartAux.ctx.canvas.parentElement;
  //         var legend = chartAux.ctx.canvas.nextElementSibling as HTMLElement;
  //         parent.removeChild(legend);
  //         // Compare id with elementId passed by and if it is the one
  //         // you want to remove just call the destroy function
  //         Chart.instances[key].destroy();
  //       }
  //     }
  //   }
  // }
}
