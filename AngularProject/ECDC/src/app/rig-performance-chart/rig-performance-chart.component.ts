import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { IRig } from 'SharedClasses/IRig';
import { Chart, registerables } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';
import { LoginService } from 'Services/login.service';
Chart.register(ChartDataLabels);
Chart.register(...registerables);


@Component({
  selector: 'app-rig-performance-chart',
  templateUrl: './rig-performance-chart.component.html',
  styleUrls: ['./rig-performance-chart.component.scss']
})
export class RigPerformanceChartComponent {
  clearChart(ID_Name: string) {
    const myElement = document.querySelector('#' + ID_Name) as HTMLElement;
    myElement.remove()
    this.RigPerformanceList = [];
    this.DateDiff = [];
    this.Months = [];
    this.YesList = [];
    this.NoList = [];
  }

  AddCanvas(ID_Name: string, DIV_Name: string) {
    // Create a new element
    var newElement = document.createElement('canvas');
    newElement.id = ID_Name

    // Get the parent element where you want to append the new element
    const myElement = document.querySelector('#' + DIV_Name) as HTMLElement;

    // Append the new element to the parent element
    myElement.appendChild(newElement);
  }

  temp: boolean = false;
  RigList: IRig[] = [];
  ErrorMessage: string = '';
  RigPerformanceList: any[] = [];
  DateDiff: any[] = [];
  Months: any[] = [];
  YesList: any[] = [];
  Yes_Count: number = 0;
  NoList: any[] = [];
  No_Count: number = 0;
  User:any;

  constructor(private dataService: DataService,private loginService:LoginService) { }

  ngOnInit(): void {
    this.User= this.loginService.currentUser.getValue();
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.dataService.GetRig().subscribe({
      next: data => {
        this.RigList = data.data
      },
      error: err => {
        this.ErrorMessage = err
      }
    })
  }

  onChange(event: any) {

    console.log(event.target.value)
    const myComboBox = document.getElementById('RigNo') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.temp = true;
    this.dataService.GetRigPerformanceDataForCharts(event.target.value,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.clearChart("myChart")
        this.RigPerformanceList = data.data,
          this.RigPerformanceList.forEach((Element) => {
            const Acceptyear = Number(Element.acceptanceDate.slice(0, 4));
            const Acceptmonth = Number(Element.acceptanceDate.slice(5, 7)) - 1; // Months are zero-indexed
            const Acceptday = Number(Element.acceptanceDate.slice(8, 10));
            const Accepthour = Number(Element.acceptanceTime.slice(0, 2));
            const Acceptminute = Number(Element.acceptanceTime.slice(3, 5));
            const Acceptsecond = Number(Element.acceptanceTime.slice(6, 8));
            const Releaseyear = Number(Element.releaseDate.slice(0, 4));
            const Releasemonth = Number(Element.releaseDate.slice(5, 7)) - 1; // Months are zero-indexed
            const Releaseday = Number(Element.releaseDate.slice(8, 10));
            const Releasehour = Number(Element.releaseTime.slice(0, 2));
            const Releaseminute = Number(Element.releaseTime.slice(3, 5));
            const Releasesecond = Number(Element.releaseTime.slice(6, 8));

            const validDate1 = new Date(Acceptyear, Acceptmonth, Acceptday, Accepthour, Acceptminute, Acceptsecond)
            const validDate2 = new Date(Releaseyear, Releasemonth, Releaseday, Releasehour, Releaseminute, Releasesecond)

            console.log(validDate1)
            console.log(validDate2)

            this.DateDiff.push(((Math.abs(validDate1.getTime() - validDate2.getTime())) / (1000 * 3600 * 24)).toFixed(2));
            console.log(this.DateDiff)

            this.Months.push((validDate2.toLocaleString('en-US', { month: 'short', }).toString()) + ' - ' + (validDate1.toLocaleString('en-US', { month: 'short', }).toString()))
          })

        this.AddCanvas("myChart", "chart1")

        var myChart = new Chart("myChart", {
          type: 'bar',
          data: {
            labels: this.Months,
            datasets: [{
              label: 'Days',
              data: this.DateDiff,
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
      },
      error: err => {
        this.ErrorMessage = err
      }
    }),
      this.dataService.GetRigPerformanceDataForCharts(event.target.value,this.User.ID,this.User.Role).subscribe({
        next: data => {
          this.clearChart("myChart2")
          data.data.forEach((element: { targetArchived: string; }) => {
            if (element.targetArchived == 'Yes') {
              this.YesList.push(element)
            }
            else if (element.targetArchived == 'No') {
              this.NoList.push(element)
            }
          });

          this.Yes_Count = this.YesList.length
          this.No_Count = this.NoList.length

          this.AddCanvas("myChart2", "chart2")

          var myChart2 = new Chart("myChart2", {
            type: 'bar',
            data: {
              labels: ["Yes", "No"],
              datasets: [{
                label: selectedText,
                data: [this.Yes_Count, this.No_Count],
                backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(54, 162, 235, 0.2)'
                ],
                borderColor: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1,
                datalabels: {
                  color: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)'
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
        },
        error: err => {
          this.ErrorMessage = err
        }
      })
  }
}
