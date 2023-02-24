import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormGroupDirective } from '@angular/forms';
import { LoginUser } from 'src/app/interfaces/LoginUser';
import { CheckUserService } from '../../services/checkUser/check-user.service';
import { AuthenticatedResponse } from '../../interfaces/AuthenticatedResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

CheckUserService;
@Component({
  selector: 'app-enter',
  templateUrl: './enter.component.html',
  styleUrls: ['./enter.component.css'],
})
export class EnterComponent implements OnInit {
  enterForm: FormGroup;
  public invalidLogin = 'not yet';
  constructor(
    private checkUser: CheckUserService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.enterForm = this.formBuilder.group({
      addEmail: ['', [Validators.required, Validators.minLength(5)]],
      addPassword: ['', [Validators.required, Validators.minLength(3)]],
    });
  }
  @ViewChild(FormGroupDirective)
  formDirective!: FormGroupDirective;

  submit() {
    console.log(this.enterForm.value, 'formvalue');
    const { addEmail, addPassword } = this.enterForm.value;

    const loginUser: LoginUser = {
      email: addEmail ?? '',
      password: addPassword ?? '',
    };
    this.checkUser.checkUser(loginUser).subscribe({
      next: (response: AuthenticatedResponse) => {
        const token = response.token;
        localStorage.setItem('jwt', token);

        this.invalidLogin = 'no';
        this.formDirective.resetForm();
        setTimeout(() => {
          this.router.navigate(['/']);
        }, 2500);
      },
      error: (err: HttpErrorResponse) => (this.invalidLogin = 'yes'),
    });

    this.enterForm.reset();
  }
  ngOnInit(): void {}
}
