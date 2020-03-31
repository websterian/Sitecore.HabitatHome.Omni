import { get } from "./GenericService";

export const StoresCount = 500;

export function getAll() {
  return get(`/stores`, { take: StoresCount }, true);
}
