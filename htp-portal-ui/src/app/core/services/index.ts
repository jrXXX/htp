import { LoadingService } from './loading/loading.service';
import { AuthStoreService } from './auth-store/auth-store.service';

export const services: any[] = [LoadingService, AuthStoreService];

export * from './auth-store/auth-store.service';
export * from './loading/loading.service';
