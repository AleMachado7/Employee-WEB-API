export interface Response<T> {
    data: T;
    message: string;
    success: boolean;
    currentPage: number;
    totalPages: number;
}