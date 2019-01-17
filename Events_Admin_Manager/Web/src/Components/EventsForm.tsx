import * as React from 'react';
import { Input, Checkbox, DropDownList, Button, TextArea } from '../common/form';
import { ITextValue } from '../common/form/ITextValue';
import { Card } from '../common/card';
import { Moment } from 'moment'
import { FileUploadWithCrop } from '../common/form/fileUploadWithCrop'
//import { FileUpload } from '../common/form/fileUpload'
import ReactCrop from 'react-image-crop';
import 'react-image-crop/dist/ReactCrop.css';

export interface IEventsForm {
    id: number,
    organizationId: number,
    eventTypeId: number,
    title: string,
    topicDesc: string,
    startDate: string,
    startTime: string,
    endDate?: string,
    endTime?: string,
    isAllDay: boolean,
    venueName: string,
    addressId: number,
    streetAddress: string,
    city: string,
    stateProvinceId: number,
    postalCode: string,
    scholarshipId: number,
    imageUrl: string,
    contactInfo: string,
    modifiedById: number,
    createdById: number
}
export interface IEventList {
    id: number,
    organizationId: number,
    eventTypeId: number,
    title: string,
    topicDesc: string,
    startDate: string,
    startTime: string,
    endDate?: string,
    endTime?: string,
    isAllDay: string,
    venueName: string,
    streetAddress: string,
    city: string,
    stateProvinceId: number,
    postalCode: string,
    stateProvinceCode: string,
    orgName: string,
    typeName: string,
    imageUrl: string,
    contactInfo: string,
    name: string
}
interface IEventsFormProps {
    events: IEventsForm,
    eventTypeList: ITextValue[],
    states: ITextValue[],
    scholarships: ITextValue[],
    organizations: ITextValue[],
    onChange: (fieldName: string, fieldValue: string) => void;
    onUploadComplete: (url) => void
    error?: any,
    errorMessage?: string,
    canvasUrl: string


}

export const EventsForm = (props: IEventsFormProps) => (
    <React.Fragment>
        <form className="form-control">
            <div className="modal-header">
                <h2 className="card-header">Event Form</h2>
                <button type="button" className="close" data-dismiss="modal" aria-label="Close">×</button>
            </div>
            <div className="card-body">
                <div className="row col-md-12">
                    <div className="form-row col-md-6 mb-4">
                        <div className="form-group col">
                            <DropDownList
                                label="Scholarship:"
                                name="scholarshipId"
                                selectedValue={props.events.scholarshipId}
                                options={props.scholarships}
                                onChange={props.onChange}
                                error={props.error.scholarshipId}
                            />
                        </div>
                    </div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <DropDownList
                            label="Event Type:"
                            name="eventTypeId"
                            selectedValue={props.events.eventTypeId}
                            options={props.eventTypeList}
                            onChange={props.onChange}
                            error={props.error.eventTypeId}
                        />
                    </div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <Input
                            type="text"
                            label="Title:"
                            name="title"
                            placeholder="Enter Title"
                            value={props.events.title}
                            onChange={props.onChange}
                            error={props.error.title}
                        />
                    </div></div>
                <div className="form-row">
                    <div className="form-group col">
                        <TextArea
                            type="textarea"
                            rows={4}
                            label="Topic Description:"
                            name="topicDesc"
                            placeholder="Enter Topic Description..."
                            value={props.events.topicDesc}
                            onChange={props.onChange}
                            error={props.error.topicDesc}
                        />
                    </div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <Input
                            type="date"
                            label="Start Date:"
                            name="startDate"
                            placeholder="MM/DD/YYYY"
                            value={props.events.startDate}
                            onChange={props.onChange}
                            error={props.error.startDate}
                        />
                    </div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <Input
                            type="time"
                            label="Start Time:"
                            name="startTime"
                            placeholder="Enter Start Time"
                            value={props.events.startTime}
                            onChange={props.onChange}
                            error={props.error.startTime}
                        />
                    </div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <p className="text-muted"> <i>(Optional)</i></p>
                        <Input
                            type="date"
                            label="End Date:"
                            name="endDate"
                            placeholder="MM/DD/YYYY"
                            value={props.events.endDate}
                            onChange={props.onChange}
                        /></div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <p className="text-muted"> <i>(Optional)</i></p>
                        <Input
                            type="time"
                            label="End Time:"
                            name="endTime"
                            placeholder="Enter End Time"
                            value={props.events.endTime}
                            onChange={props.onChange}
                        />
                    </div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <Checkbox
                            name="isAllDay"
                            label="All Day Event?"
                            checked={props.events.isAllDay}
                            onCheck={props.onChange}
                        />
                    </div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <Input
                            type="text"
                            label="Venue Name:"
                            name="venueName"
                            placeholder="Enter Venue Name..."
                            value={props.events.venueName}
                            onChange={props.onChange}
                            error={props.error.venueName}
                        />
                    </div>
                </div>
                <div className="card-header">
                    <h3><strong>Address:</strong></h3>
                </div>
                <div className="card-body">
                    <div className="row">
                        <div className="form-row col-md-6 mb-5">
                            <div className="form-group col">
                                <Input
                                    type="text"
                                    label="Street:"
                                    name="streetAddress"
                                    placeholder="Enter Street Name..."
                                    value={props.events.streetAddress}
                                    onChange={props.onChange}
                                    error={props.error.streetAddress}
                                />
                            </div>
                        </div>
                        <div className="form-row col-md-6 mb-5">
                            <div className="form-group col">
                                <Input
                                    type="text"
                                    label="City:"
                                    name="city"
                                    placeholder="Enter City Name..."
                                    value={props.events.city}
                                    onChange={props.onChange}
                                    error={props.error.city}
                                />
                            </div>
                        </div>
                        <div className="form-row col-md-6 mb-5">
                            <div className="form-group col">
                                <DropDownList
                                    label="Select State:"
                                    name="stateProvinceId"
                                    selectedValue={props.events.stateProvinceId}
                                    options={props.states}
                                    onChange={props.onChange}
                                    error={props.error.stateProvinceId}
                                />
                            </div>
                        </div>
                        <div className="form-row col-md-6 mb-5">
                            <div className="form-group col">
                                <Input
                                    type="number"
                                    label="Postal Code:"
                                    name="postalCode"
                                    placeholder="Enter Postal Code"
                                    value={props.events.postalCode}
                                    onChange={props.onChange}
                                    error={props.error.postalCode}
                                />
                            </div>
                        </div>
                    </div>
                </div>
                <div className="form-row">
                    <div className="form-group col">
                        <TextArea
                            type="textarea"
                            rows={4}
                            maxLength={200}
                            label="Contact Info:"
                            name="contactInfo"
                            placeholder="Enter Contact Info..."
                            value={props.events.contactInfo}
                            onChange={props.onChange}
                            error={props.error.contactInfo}
                        />
                    </div>
                </div>
                <div className="row justify-content-md-center">
                    <div>
                        <div className="text-center"><i style={{ color: "red" }}>(Required)</i> </div>
                        <p className="text-center">Upload an image:</p>
                        <FileUploadWithCrop
                            onUploadComplete={props.onUploadComplete}
                            canvasUrl={props.events.imageUrl}
                            aspRatio="landscape"
                            buttonName="Upload Event Image"
                        />
                    </div>
                </div>
            </div>
        </form>
    </React.Fragment >
)