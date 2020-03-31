import { get, post } from "./GenericService";

export const ProductDisplayCount = 4;

export function getAll() {
  return get(`/products`, { take: ProductDisplayCount }, true);
}

export function search(query, page, pageSize)  {
  return post(`/stores/search`, { q: query, pg: page, ps: pageSize});
}
