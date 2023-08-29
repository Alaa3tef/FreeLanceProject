import { ChangeDetectorRef, Component } from '@angular/core';
import { AddnewJMPService } from 'Services/addnew-jmp.service';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { IJMP } from 'SharedClasses/IJMP';
import { BehaviorSubject, distinctUntilChanged } from 'rxjs';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.scss']
})
export class NotificationsComponent {
  public ListOfSJPs = new BehaviorSubject<any[]>([]);
  readonly SJPsList = this.ListOfSJPs.asObservable();
  page: number = 1;
  count: number = 0;
  productSize: number = 5;
  indexofPages: number = 1;
  countOfPage: number = 0;
  TempArray: any[] = [];

  constructor(private JMPService:AddnewJMPService,private cdRef: ChangeDetectorRef, private dataService: DataService, private editService: EditDataService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getpages(1)
  }

  Aprrove(id: number, notifyStatus: number, item: IJMP) {
    this.editService.EditNotifiyStatus(id, notifyStatus, item).subscribe({
      next: data => {
        console.log(data)
        this.getpages(this.indexofPages)
      },
      error: err => {
        console.log(err)
      }
    })
  }

  Reject(id: number, notifyStatus: number, item: IJMP) {
    this.editService.EditNotifiyStatus(id, notifyStatus, item).subscribe({
      next: data => {
        console.log(data)
        this.getpages(this.indexofPages)
      },
      error: err => {
        console.log(err)
      }
    })
  }

  getpages(num: number) {
    this.dataService.GetPendingJMP(num).subscribe({
      next: data => {
        console.log("data.items.length")
        console.log(data.items.length)
        this.ListOfSJPs.next(data.items)
        this.JMPService.PendingJMP.next(data.items.length)
        this.countOfPage = data.count;
        this.TempArray = new Array(this.countOfPage);
      },
      error: err => {
        console.log(err)
      }
    })
    this.indexofPages = num;
    console.log("getpages" + this.indexofPages);
  }
  gotleft() {
    (this.indexofPages > 1) ? this.indexofPages -= 1 : this.indexofPages = 1;
    this.getpages(this.indexofPages);
    console.log("gotleft" + this.indexofPages);
  }
  gotoright() {

    (this.indexofPages < this.countOfPage) ? this.indexofPages += 1 : this.indexofPages = this.countOfPage;
    this.getpages(this.indexofPages);
    console.log("gotoright" + this.indexofPages);
  }
}
