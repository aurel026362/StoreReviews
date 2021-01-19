export class PagedResultModel<T> {
    currentPage: number;
    totalPages: number;
    pageSize: number;
    results: T[];
}