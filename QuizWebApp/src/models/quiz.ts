export type Topic = {
    topicId: number,
    name: string,
    description: string,
    imageUrl: string,
    quizzes: Quiz[]
}

export type Quiz = {
    quizId: number,
    name: string
}