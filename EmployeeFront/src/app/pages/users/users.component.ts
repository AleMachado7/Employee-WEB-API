import { Component, OnInit } from '@angular/core';
import { UserResult } from 'src/app/models/User/UserResult';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  users: UserResult[] = [];
  tableColumns: string[] = ['Status', 'Email'];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe((usersData) => {
      this.users = usersData.data;
    });
  }
}
