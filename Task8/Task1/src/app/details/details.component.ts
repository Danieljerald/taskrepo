import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';


export class EmpData {
  property1: number;
  property2: string;
  property3: string;
  property4: string;
  property5: number;

  constructor(prop1: number, prop2: string,prop3: string,prop4: string,prop5: number) {
    this.property1 = prop1;
    this.property2 = prop2;
    this.property3 = prop3;
    this.property4 = prop4;
    this.property5 = prop5;
  }

}
@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  hideToggle : boolean ;
  dataArray: EmpData[] = [];
  
  constructor(){
     this.hideToggle = false;
  }
    addData(formdata:any){

      const newData=new EmpData(formdata.empId,formdata.empname,formdata.designation,formdata.address,formdata.salary);
      this.dataArray.push(newData);
    }
  onButtonClick(){
    if(this.hideToggle == false){
      this.hideToggle = true;
    }
    else{
      this.hideToggle = false;
    }
    console.log(this.hideToggle);
  }
}
