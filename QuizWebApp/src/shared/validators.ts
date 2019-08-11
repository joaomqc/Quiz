export const isEmailValid = (email: string) => {
    return /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(email);
}

export const isUsernameValid = (username: string) => {
    return username.length >= 3
        && username.length <= 20;
}

export const isPasswordValid = (password: string) => {
    return password.length >= 8;
}