export function getTopics() {
    return [
        {
            topicId: 1,
            name: 'Science',
            description: 'Science quizzes',
            imageUrl: 'https://png.pngtree.com/svg/20160719/2325f4609e.svg',
            quizzes: [
                {
                    quizId: 1,
                    name: 'Genetic Diseases 101'
                }
            ]
        },
        {
            topicId: 2,
            name: 'Tech',
            description: 'Tech quizzes',
            imageUrl: 'https://png.pngtree.com/svg/20161018/17cd13a19d.svg',
            quizzes: [
                {
                    quizId: 2,
                    name: 'A Brief History of Computers'
                }
            ]
        }
    ]
}