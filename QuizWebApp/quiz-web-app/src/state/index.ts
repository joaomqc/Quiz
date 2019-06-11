import { combineReducers } from 'redux';

import { default as usersReducer } from './users/reducer';
import { root as usersRoot } from './users/selectors';

export const rootReducer = combineReducers({
    [usersRoot]: usersReducer
});

export type AppState = ReturnType<typeof rootReducer>;