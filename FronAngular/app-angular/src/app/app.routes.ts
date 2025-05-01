import { Routes } from '@angular/router';
import { ListPersonComponent } from './components/person/list-person/list-person.component';
import { CreatePersonComponent } from './components/person/create-person/create-person.component';
import { ListRolComponent } from './components/rol/list-rol/list-rol.component';
import { CreateRolComponent } from './components/rol/create-rol/create-rol.component';
import { FormListComponent } from './components/form/form-list/form-list.component';
import { ListMuduleComponent } from './components/module/list-mudule/list-mudule.component';
import { ListUserComponent } from './components/user/list-user/list-user.component';
import { ListPermissionComponent } from './components/permission/list-permission/list-permission.component';
import { ListRolFormPermissionComponent } from './components/rolFormPermission/list-rol-form-permission/list-rol-form-permission.component';
import { ListRolUserComponent } from './components/rolUser/list-rol-user/list-rol-user.component';
import { ListFormModuleComponent } from './components/formModule/list-form-module/list-form-module.component';
import { CreateFormComponent } from './components/form/create-form/create-form.component';
import { EditFormComponent } from './components/form/edit-form/edit-form.component';
import { CreateMuduleComponent } from './components/module/create-mudule/create-mudule.component';
import { EditModuleComponent } from './components/module/edit-module/edit-module.component';
import { CreatePermissionComponent } from './components/permission/create-permission/create-permission.component';
import { EditPermissionComponent } from './components/permission/edit-permission/edit-permission.component';
import { CreateUserComponent } from './components/user/create-user/create-user.component';
import { EditUserComponent } from './components/user/edit-user/edit-user.component';
import { EditPersonComponent } from './components/person/edit-person/edit-person.component';
import { CreateRolFormPermissionComponent } from './components/rolFormPermission/create-rol-form-permission/create-rol-form-permission.component';
import { EditRolFormPermissionComponent } from './components/rolFormPermission/edit-rol-form-permission/edit-rol-form-permission.component';
import { CreateRolUserComponent } from './components/rolUser/create-rol-user/create-rol-user.component';
import { EditRolUserComponent } from './components/rolUser/edit-rol-user/edit-rol-user.component';
import { CreateFormModuleComponent } from './components/formModule/create-form-module/create-form-module.component';
import { EditFormModuleComponent } from './components/formModule/edit-form-module/edit-form-module.component';
import { EditRolComponent } from './components/rol/edit-rol/edit-rol.component';
import { LoginComponent } from './components/login/login/login.component';
import { ListDeletesComponent } from './components/form/list-deletes/list-deletes.component';

export const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    {path: 'login', component: LoginComponent},


    { path: 'person', component: ListPersonComponent },
    { path: 'person/create', component: CreatePersonComponent },
    { path: 'person/update/:id', component: EditPersonComponent },

    { path: 'rol', component: ListRolComponent },
    { path: 'rol/create', component: CreateRolComponent },
    { path: 'rol/update/:id', component: EditRolComponent },

    { path: 'form', component: FormListComponent },
    { path: 'form/create', component: CreateFormComponent },
    { path: 'form/update/:id', component: EditFormComponent },
    { path: 'form/listDetele', component: ListDeletesComponent },


    { path: 'module', component: ListMuduleComponent },
    { path: 'module/create', component: CreateMuduleComponent },
    { path: 'module/update/:id', component: EditModuleComponent },

    { path: 'user', component: ListUserComponent },
    { path: 'user/create', component: CreateUserComponent },
    { path: 'user/update/:id', component: EditUserComponent },

    { path: 'permission', component: ListPermissionComponent },
    { path: 'permission/create', component: CreatePermissionComponent },
    { path: 'permission/update/:id', component: EditPermissionComponent },

    { path: 'rolFormPermission', component: ListRolFormPermissionComponent },
    { path: 'rolFormPermission/create', component: CreateRolFormPermissionComponent },
    { path: 'rolFormPermission/update/:id', component: EditRolFormPermissionComponent },

    { path: 'rolUser', component: ListRolUserComponent },
    { path: 'rolUser/create', component: CreateRolUserComponent },
    { path: 'rolUser/update/:id', component: EditRolUserComponent },

    { path: 'formModule', component: ListFormModuleComponent },
    { path: 'formModule/create', component: CreateFormModuleComponent },
    { path: 'formModule/update/:id', component: EditFormModuleComponent },
];
