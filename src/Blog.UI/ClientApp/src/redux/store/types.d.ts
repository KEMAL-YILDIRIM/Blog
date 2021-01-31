import { ActionType, StateType } from 'typesafe-actions'

declare module 'InternalTypes' {
  export type Store = StateType<typeof import('./store').default>
  export type RootState = StateType<
    ReturnType<typeof import('./root-reducer').default>
  >
}
