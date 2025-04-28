import { Component, inject } from '@angular/core';
import { User } from '../../../Models/user/user.models';
import { UserService } from '../../../Services/user/user.service';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-list-user',
  imports: [MatButtonModule, RouterLink, MatTableModule],
  templateUrl: './list-user.component.html',
  styleUrl: './list-user.component.css'
})
export class ListUserComponent {
  userServices = inject(UserService);
  users?: User[];
  columns = ['user_name', 'email', 'name_Person', 'action']

  constructor() {
    this.getAll();
  }

  public getAll() {
    this.userServices.getAllUser().subscribe(users => {
      this.users = users;
    });
  }

  deleteLogic(id: number, nul: []) {
    this.userServices.logicalDelete(id, nul).subscribe(() => {
      console.log("Se elimino Logicamnete")
      this.getAll();
    })
  }

}
