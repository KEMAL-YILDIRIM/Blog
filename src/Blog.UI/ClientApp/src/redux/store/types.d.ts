import { ActionType, StateType } from 'typesafe-actions'

declare module 'InternalTypes' {
  export type Store = StateType<typeof import('./store').default>
  export type RootAction = ActionType<typeof import('./root-action').default>
  export type RootState = StateType<
    ReturnType<typeof import('./root-reducer').default>
  >
}

declare module 'typesafe-actions' {
  interface Types {
    RootAction: ActionType<typeof import('./root-action').default>
  }
}
