import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { RolService } from '../../../Services/Rol/rol.service';
import { Rol } from '../../../Models/Rol/Rol.models';

@Component({
  selector: 'app-list-rol',
  imports: [MatButtonModule, RouterLink, MatTableModule],
  templateUrl: './list-rol.component.html',
  styleUrl: './list-rol.component.css'
})
export class ListRolComponent {

  rolServices = inject(RolService);
  rols?: Rol[];
  columns = ['name', 'description', 'action']

  constructor() {
    this.getAll();
  }

  public getAll() {
    this.rolServices.getAllRol().subscribe(rols => {
      this.rols = rols;
    });
  }
}
