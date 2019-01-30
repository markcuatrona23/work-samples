import * as React from 'react';
import { IEventList } from './EventsForm';
import { EventsApi } from './EventsApi';
import { EventsPublicForm } from './EventsPublicForm';

interface IEventsPublicPage {
    allEventsList: IEventList[]
}
class EventsPublicPage extends React.Component<any, IEventsPublicPage>{
    constructor(props) {
        super(props);
        this.state = {
            allEventsList: []
        }
    }
    getAllEventsRegardlessOfId = () => {
        EventsApi.getAllEvents()
            .then(response => {
                let items = response.items.sort(function (a, b) {
                    return Number(new Date(a.startDate)) - Number(new Date(b.startDate))
                })
                console.log(response);
                this.setState({
                    ...this.state,
                    allEventsList: response.items
                })

            })
            .catch(err => console.log(err))
    }
    componentDidMount() {
        this.getAllEventsRegardlessOfId();
    }
    render() {
        return (
            <div>
                <EventsPublicForm
                    allEventsList={this.state.allEventsList}
                />
            </div>
        )
    }
}

export default EventsPublicPage;