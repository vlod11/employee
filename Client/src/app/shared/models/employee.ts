export class Employee {
    id: string;
    name: string;
    surname: string;
    salary: number;
    lastJobTitle: string;
    hiredAtUtc: Date;
    leftAtUtc: Date;

    public static assemble(dto: any) {
        const result = new Employee();
        if (dto) {
            result.id = dto.id;
            result.name = dto.name + ' ' + dto.surname;

            const lastJob = dto.positions.sort((a, b) => {
                const lastJobDiff = b.hiredAtUtc - a.hiredAtUtc;
                if (lastJobDiff) { return lastJobDiff; }
            })[0];

            result.lastJobTitle = lastJob.title;
            result.hiredAtUtc = lastJob.hiredAtUtc;
            result.leftAtUtc = lastJob.leftAtUtc;
            result.salary = lastJob.salary;
        }
        return result;
    }
}
