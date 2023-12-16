import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { UserService } from '../services/user/user.service';
import { map, take } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const userService: UserService = inject(UserService);
  const router: Router = inject(Router);

  return userService.getCurrentUser().pipe(
    take(1),
    map((result) => {
      if (!result.data) {
        return router.createUrlTree(['/login']);
      } else {
        return true;
      }
    })
  );
};
