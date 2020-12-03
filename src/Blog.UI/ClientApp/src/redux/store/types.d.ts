import {StateType,ActionType} from 'typesafe-actions'

declare module 'InternalTypes' {
    export type Store = StateType<typeof import('./index').default>;
}