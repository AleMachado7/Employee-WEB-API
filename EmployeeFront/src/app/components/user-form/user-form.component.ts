import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserParams } from 'src/app/models/User/UserParams';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css'],
})
export class UserFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<UserParams>();
  @Input() formTitle!: string;
  @Input() btnAction!: string;
  loginForm!: FormGroup;

  constructor() {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    });
  }

  submit(): void {
    if (this.loginForm.valid) {
      this.onSubmit.emit(this.loginForm.value);
    }
  }
}
