import * as React from 'react';

import { Topic } from 'models/quiz';

type Props = {
    topics: Topic[]
}

export default class Home extends React.Component<Props> {
    render(){
        return (
            <div className="mt-5">
                {this.props.topics.map(topic =>
                    <div className="text-left ml-5 mb-5">
                        <div className="mb-3">
                            <img
                                className="topic-icon mr-3"
                                key={topic.topicId}
                                src={topic.imageUrl}
                                alt={topic.name} />

                            <span>{topic.name}</span>
                        </div>
                        {topic.quizzes.map(quiz =>
                            <div className="quiz-box cursor-pointer">
                                <img
                                    className="border rounded quiz-icon"
                                    key={quiz.quizId}
                                    src={topic.imageUrl}
                                    alt={quiz.name} />

                                <div>{quiz.name}</div>
                            </div>)}
                    </div>)}
            </div>
        );
    }
}