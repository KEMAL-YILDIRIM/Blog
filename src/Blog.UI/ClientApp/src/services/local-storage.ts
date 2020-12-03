const version = process.env.APP_VERSION;
const store_key = `__STATE_v${version}__`


export function saveState<T = object>(storeState: T): boolean {
    if (!localStorage) return false;

    try {
        const stateJson = JSON.stringify(storeState);
        localStorage.setItem(store_key, stateJson);
        return true;
    } catch (error) {
        throw error;
    }
}

export function retrieveState<T = object>():T|undefined{
    if (!localStorage) return;

    try {
        const stateJson = localStorage.getItem(store_key);
        if(stateJson === null) return;
        return JSON.parse(stateJson);
    } catch (error) {
        throw error;
    }
}