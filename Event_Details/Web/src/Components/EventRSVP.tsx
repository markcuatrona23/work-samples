import * as React from 'react';
import { Card } from '../common/card';
import { DropDownList } from '../common/form/'
import { ITextValue } from '../common/form/ITextValue';

interface IEventRSVPProps {
    options: ITextValue[],
    onChange: (fieldName: string, fieldValue: string) => void;
    payload: {
        eventId: any,
        userBaseId: number,
        rsvpTypeId: number
    }
    onSubmitRSVP: () => void;
}

export const EventRSVP = (props: IEventRSVPProps) => (
    <React.Fragment>
        <div>
            <DropDownList
                label="Will you be attending?"
                name="rsvpTypeId"
                options={props.options}
                onChange={props.onChange}
                selectedValue={props.payload.rsvpTypeId} />

            <button
                className="btn btn-sm btn-primary float-right"
                onClick={props.onSubmitRSVP}
            >Submit</button>
        </div>
    </React.Fragment>
)

export default EventRSVP;